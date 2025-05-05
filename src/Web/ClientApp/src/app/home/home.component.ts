import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Partido, PartidoClient, Pronostico } from './home.client';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  form: FormGroup;

  partidos: Partido[];
  pronosticos: Pronostico[] = [];

  constructor(private fb: FormBuilder,
              private client: PartidoClient
  ) {
    this.form = this.fb.group({});
  }

  ngOnInit(): void {
    this.client.getPartidos().subscribe({
      next: (data) => {
        this.partidos = data;
        this.pronosticos = this.partidos.map(partido => ({
          partidoId: partido.id,
          resultado: null,  
        }));        
        this.partidos.forEach(partido => {
        this.form.addControl(`match_${partido.id}`, this.fb.control(null));
        });
      },
      error: () => {
      }
    })
  }
  guardarPronosticos() {
    console.log(this.pronosticos);
    this.client.guardarPronosticos(this.pronosticos).subscribe({
      next: (data) => {
        
      },
      error: () => {
      }
    });
  }

  seleccionarResultado(index: number, resultado: number): void {
    this.pronosticos[index].resultado = resultado;
  }


  todosPronosticados(): boolean {
    let response: boolean = false;
    if (this.pronosticos && this.partidos) {
      response = this.pronosticos?.length === this.partidos?.length &&
           this.pronosticos.every(p => p.resultado !== null && p.resultado !== undefined);
    }
    return response;
  }  
}
