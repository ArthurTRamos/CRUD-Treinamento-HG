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

  myForms = new FormGroup({
    name: new FormControl<string>('', {
      validators: [Validators.required],
      nonNullable: true
    }),

    number: new FormControl<string>('', {
      validators: [
        Validators.required,
        Validators.pattern(/^\d{13}$/)
      ],
      nonNullable: true
    })
  });

  ngOnInit(): void {
    if (this.contact) {
      this.myForms.patchValue({
        name: this.contact.name,
        number: this.contact.number
      });
      console.log(this.contact)
    }
  }

  sendData() {
    if (this.myForms.invalid) {
      this.myForms.markAllAsTouched();

      let message = 'Por favor, corrija os erros no formulário:\n';
      
      if (this.myForms.controls.name.errors?.['required'])
        message += '- O nome é obrigatório.\n';
      
      if (this.myForms.controls.number.errors?.['required']) {
        message += '- O número é obrigatório.\n';
      } else if (this.myForms.controls.number.errors?.['pattern']) {
        message += '- O número deve conter exatamente 13 dígitos numéricos.\n';
      }

      alert(message);
      return;
    }

    const data = this.myForms.getRawValue();
    this.save.emit({
      name: data.name,
      number: data.number
    });
  }

  out(){
    this.back.emit();
  }
}