import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { MatIconModule } from '@angular/material/icon';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { CreateUpdatePage } from './create-update-page/create-update-page';
import { MainPage } from './main-page/main-page';
import { Button } from './button/button';
import { ContactBox } from './contact-box/contact-box';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [App, CreateUpdatePage, MainPage, Button, ContactBox],
  imports: [BrowserModule, MatIconModule, AppRoutingModule, ReactiveFormsModule],
  providers: [provideBrowserGlobalErrorListeners()],
  bootstrap: [App],
})
export class AppModule {}
