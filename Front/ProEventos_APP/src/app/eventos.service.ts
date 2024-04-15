import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EventoModel } from 'EventoModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventosService {
  url = "https://localhost:5001/api/evento/"
  constructor(private http: HttpClient) {
     
   }

   getEventos(): Observable<EventoModel[]>{
    return this.http.get<EventoModel[]>(this.url)
   }

   getEventosById(id: string): Observable<EventoModel>{
    const UrlId = `${this.url}/${id}`
    return this.http.get<EventoModel>(UrlId)
   }


}
