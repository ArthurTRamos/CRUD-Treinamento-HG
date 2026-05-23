import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ServiceMainPage {
  constructor(private readonly httpClient: HttpClient) {}

  getContacts() {
    return this.httpClient.get<any>('');
  }

  saveNewContact() {
    this.httpClient.post<any>('');
  }

  updateContact() {
    this.httpClient.put<any>('');
  }

  deleteContact() {
    return this.httpClient.delete('');
  }
}
