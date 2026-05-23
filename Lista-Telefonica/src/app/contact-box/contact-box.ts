import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ServiceContacts } from '../service-contacts';

@Component({
  selector: 'app-contact-box',
  standalone: false,
  templateUrl: './contact-box.html',
  styleUrl: './contact-box.scss',
})

export class ContactBox {
  selectedContact: any = null;

  constructor(private readonly service: ServiceContacts) {}
  
  @Input()
  visualizationMode!: string;

  @Output()
  visualizationModeChange = new EventEmitter<string>();

  contacts: {id: number, name: string, number: string}[] = [];

  getContacts() {
    this.service.getContacts().subscribe({
      next: (response: any) => {
        this.contacts = response;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  getInitialLetters(name: string) {
    const words = name.split(" ");
    const firstName = words[0];
    const lastName = words[words.length - 1];

    if(words.length == 1) {
      if(firstName.length == 1)
        return firstName[0] + firstName[0];
      return firstName[0] + firstName[1];
    }
    
    return firstName[0] + lastName[0];
  }

  formatNumber(number: string) {
    const ddi: string = number.slice(0, 2);
    const dd: string = number.slice(2, 4);
    const phoneNumber: string = number.slice(4);

    return "+" + ddi + " " + dd + " " + phoneNumber;
  }

  whatsappLink(number: string) {
    number = number.slice(1);
    return(`http://wa.me/${number.replaceAll(' ', '')}`);
  }

  getContact(id: number, name: string, number: string) {
    this.selectedContact = {
      "id": id,
      "name": name,
      "number": number
    }
  }

  createContact(name: string, number: string) { 
    number = number.replaceAll(" ", "");

    const newContact = {
      id: this.contacts.length + 1,
      name,
      number
    };
    this.contacts = [...this.contacts, newContact];
  }

  editContact(id: number, name: string, number: string) {
    this.contacts = this.contacts.map(contact => {
      if (contact.id === id) {
        return {
          ...contact,
          name: name,
          number: number
        };
      }
      return contact;
    });
  }

  deleteContact(contact: {id: number, name: string, number: string}) {
    this.contacts = this.contacts.filter(contactItem => contactItem.id !== contact.id); 
  }

  initEditMode() {
    this.visualizationModeChange.emit('edit');
  }

  shutdowCreateUpdateMode() {
    this.visualizationModeChange.emit('main');
  }
}