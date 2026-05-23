import { Component } from '@angular/core';

@Component({
  selector: 'app-main-page',
  standalone: false,
  templateUrl: './main-page.html',
  styleUrl: './main-page.scss',
})
export class MainPage {

  visualizationMode = 'main';

  setVisualizationMode(mode: string) {
    this.visualizationMode = mode;
  }
}
