import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent{

  public eventos: any = [{Tema: 'Angular', Local: 'belo horizonte'},
  {Tema: 'C#', Local: 'Fortaleza'},
  {Tema: 'GIT', Local: 'São paulo'}
  ]

}
