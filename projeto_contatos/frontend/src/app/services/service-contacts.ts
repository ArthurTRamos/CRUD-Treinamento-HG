import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ServiceContacts {
  constructor(private readonly httpClient: HttpClient) {}

  getContacts() {
    return this.httpClient.get<any>('http://localhost:8081/api/contacts');
  }

  saveNewContact(newContact: any) {
    return this.httpClient.post<any>('http://localhost:8081/api/contacts', newContact);
  }

  updateContact(id: number, updatedContact: any) {
    return this.httpClient.put<any>(`http://localhost:8081/api/contacts/${id}`, updatedContact);
  }

  deleteContact(id: number) {
    return this.httpClient.delete(`http://localhost:8081/api/contacts/${id}`);
  }
}
