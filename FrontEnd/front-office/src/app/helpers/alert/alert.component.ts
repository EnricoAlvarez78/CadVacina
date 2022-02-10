import { Component } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css']
})
export class AlertComponent extends SimpleModalComponent<AlertModel, boolean> implements AlertModel {
  title: string = '';
  message: string = '';
  constructor() {
    super();
  }

  ok() {
    this.result = true;
    this.close();
  }
}

export interface AlertModel {
  title:string;
  message:string;
}
