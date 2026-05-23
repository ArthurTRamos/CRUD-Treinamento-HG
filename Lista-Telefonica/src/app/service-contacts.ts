import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ServiceContacts {
  constructor(private readonly httpClient: HttpClient) {}

  getContacts() {
    return this.httpClient.get<any>('localhost:/contacts');
  }

  saveNewContact(newContact: any) {
    this.httpClient.post<any>('localhost:/contacts', newContact);
  }

  updateContact(id: number, updatedContact: any) {
    this.httpClient.put<any>(`localhost:/contacts/${id}`, updatedContact);
  }

  deleteContact(id: number) {
    return this.httpClient.delete(`localhost:/contacts/${id}`);
  }
}
