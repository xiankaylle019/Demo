import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Http, RequestOptions } from '@angular/http';

import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-todolist',
  templateUrl: './todolist.component.html',
  styleUrls: ['./todolist.component.css']
})

export class TodolistComponent implements OnInit {
  todos:any;
  baseUrl = environment.apiUrl;
  description: string;  
  
  constructor(private http:Http) { }

  ngOnInit() {
    this.getTodoList();
  }
  
  getTodoList(){
    this.http.get(this.baseUrl + 'get')
    .subscribe(res => {
      this.todos = res.json();     
    });
  }

  addTodo(){
    
    let todo = { 
      Description : this.description 
    };

    this.http.post(this.baseUrl + 'addtodo',todo)
    .subscribe(res => {
      console.log(res);
      this.getTodoList();
    });
    this.description = "";
  }
  
  setDone(e, todo){

    todo.isAccomplished = e.target.checked;

    this.http.put(this.baseUrl + 'updatedtodo/' + todo.id, todo).subscribe(res => {
      this.getTodoList();
      console.log(res);
    
    });

  }
}
