import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  http: HttpClient = inject(HttpClient)

  baseApiUrl: string = 'https://localhost:7260/Task/'

  getTask(){
    return this.http.get<TaskResponse[]>(`${this.baseApiUrl}`)
  }
  
}
