export class EventoModel {
    eventoId: number;
    local: string;
    dataEvento: string;
    tema: string;
    qtdPessoas: number;
    lote: string;
    imagemURL: string;
  
    constructor(eventoId: number, local: string, dataEvento: string, tema: string, qtdPessoas: number, lote: string, imagemURL: string) {
      this.eventoId = eventoId;
      this.local = local;
      this.dataEvento = dataEvento;
      this.tema = tema;
      this.qtdPessoas = qtdPessoas;
      this.lote = lote;
      this.imagemURL = imagemURL;
    }
  }
  