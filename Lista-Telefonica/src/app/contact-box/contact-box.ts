import { Component } from '@angular/core';

@Component({
  selector: 'app-contact-box',
  standalone: false,
  templateUrl: './contact-box.html',
  styleUrl: './contact-box.scss',
})
export class ContactBox {
  contacts: {name: string, number: string}[] = [
    {
      "name": "Art",
      "number": "+55 19 950211842"
    },
    {
      "name": "Mai",
      "number": "+55 22 222"
    }
  ]

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

  whatsappLink(number: string) {
    number = number.slice(1);
    return(`http://wa.me/${number.replaceAll(' ', '')}`);
  }
}
