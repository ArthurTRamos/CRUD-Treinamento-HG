import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-create-update-page',
  standalone: false,
  templateUrl: './create-update-page.html',
  styleUrl: './create-update-page.scss',
})
export class CreateUpdatePage {
  @Input()
  VisualizationMode!: 'create' | 'edit';

  meuFormulario = new FormGroup({
    nome: new FormControl<string>('', {
      validators: [Validators.required]
    }),
    numero: new FormControl<number>(0, {
      validators: [Validators.required]
    })
  });

  enviarDados() {

    const dados = this.meuFormulario.value;

    console.log(dados.nome);
    console.log(dados.numero);
  }
}
