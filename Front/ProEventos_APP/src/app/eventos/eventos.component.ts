import { Component, OnInit } from '@angular/core';
import { EventosService } from '../eventos.service';
import { EventoModel } from 'EventoModel';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit{

  public eventos!: EventoModel[]

  constructor(public eventoservices:EventosService) {
    
    
  }

  ngOnInit(): void {
    this.geteventos()
  }

  public geteventos(){
    this.eventoservices.getEventos().subscribe(res => this.eventos = res)
  }

}
