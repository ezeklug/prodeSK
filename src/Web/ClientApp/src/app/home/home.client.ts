import { API_BASE_URL, SwaggerException } from "../web-api-client";
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export interface IPartidoClient {
    getPartidos(): Observable<Partido[]>;
    guardarPronosticos(pronosticos: Pronostico[]): Observable<boolean>;
}

@Injectable({
    providedIn: 'root'
})
export class PartidoClient implements IPartidoClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ?? "";
    }

    getPartidos(): Observable<Partido[]> {
        let url_ = this.baseUrl + "/api/Partidos";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetWeatherForecasts(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetWeatherForecasts(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<Partido[]>;
                }
            } else
                return _observableThrow(response_) as any as Observable<Partido[]>;
        }));
    }

    protected processGetWeatherForecasts(response: HttpResponseBase): Observable<Partido[]> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(Partido.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    guardarPronosticos(pronosticos: Pronostico[]): Observable<boolean> {
        const url_ = this.baseUrl + "/api/Pronosticos";
    
        // Envolver el array en un objeto con propiedad `pronosticos`
        const content_ = JSON.stringify({ pronosticos });
    
        const options_: any = {
            body: content_,
            observe: "response",
            responseType: "json",  // como ya corregiste antes
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };
    
        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGuardarPronosticos(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGuardarPronosticos(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<boolean>;
                }
            } else
                return _observableThrow(response_) as any as Observable<boolean>;
        }));
    }
    
    protected processGuardarPronosticos(response: HttpResponse<any>): Observable<boolean> {
        const status = response.status;
    
        // Verificar el código de estado HTTP
        if (status === 201 || status === 200 || status === 204) {
            // La operación fue exitosa
            return _observableOf(true);
        } else {
            // La operación falló
            return _observableOf(false);
        }
    }          
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((event.target as any).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}

export class Partido implements IPartido {
    id?: number;
    equipoLocal?: string;
    equipoVisitante?: string;

    constructor(data?: IPartido) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.equipoLocal = _data["equipoLocal"];
            this.equipoVisitante = _data["equipoVisitante"];
        }
    }

    static fromJS(data: any): Partido {
        data = typeof data === 'object' ? data : {};
        let result = new Partido();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["equipoLocal"] = this.equipoLocal;
        data["equipoVisitante"] = this.equipoVisitante;
        return data;
    }
}

export interface IPartido {
    id?: number;
    equipoLocal?: string;
    equipoVisitante?: string;
}

export interface IPronostico {
    partidoId: number;
    resultado: number;
}

export class Pronostico implements IPronostico {
    partidoId: number;
    resultado: number;
}