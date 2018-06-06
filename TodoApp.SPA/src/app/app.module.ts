import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http'
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { TodolistComponent } from './todolist/todolist.component';
import {FormsModule} from '@angular/forms';
import { SampleComponent } from './sample/sample.component'

@NgModule({
  declarations: [
    AppComponent,
    TodolistComponent,
    SampleComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
