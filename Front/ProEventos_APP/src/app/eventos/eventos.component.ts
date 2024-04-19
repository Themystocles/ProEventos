import { Component, OnInit } from '@angular/core';
import { EventosService } from '../eventos.service';
import { EventoModel } from 'EventoModel';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit{

  public eventos: EventoModel[] = []
  public eventosById?: EventoModel 
  public eventoId! : string
  

  constructor(public eventoservices:EventosService) {
    
    
  }

  ngOnInit(): void {
    this.geteventos()
    this.getEventosById()
  }

  public geteventos(){
    this.eventoservices.getEventos().subscribe(res => this.eventos = res)
  }

  public getEventosById(){
    
    this.eventoservices.getEventosById(this.eventoId).subscribe(res => this.eventosById = res)

  }

}
