import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-create-update-page',
  standalone: false,
  templateUrl: './create-update-page.html',
  styleUrl: './create-update-page.scss',
})
export class CreateUpdatePage implements OnInit {

  @Input()
  visualizationMode!: string;

  @Input()
  contact?: { id: number, name: string, number: string };

  @Output()
  save = new EventEmitter<{
    name: string;
    number: string;
  }>();

  @Output()
  back = new EventEmitter();

  meuFormulario = new FormGroup({
    nome: new FormControl<string>('', {
      validators: [Validators.required],
      nonNullable: true
    }),

    numero: new FormControl<string>('', {
      validators: [Validators.required],
      nonNullable: true
    })
  });

  ngOnInit(): void {

    if (this.contact) {

      this.meuFormulario.patchValue({
        nome: this.contact.name,
        numero: this.contact.number
      });

      console.log(this.contact)

    }
  }

  enviarDados() {

    const dados = this.meuFormulario.getRawValue();

    this.save.emit({
      name: dados.nome,
      number: dados.numero
    });
  }

  out(){
    this.back.emit();
  }
}
