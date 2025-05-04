import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Auth_Token } from '../data/interfaces/auth.interface';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceTsService {
  http: HttpClient = inject(HttpClient)

  baseApiUrl: string = 'https://localhost:7260'

  login(IndividualNumber: number, password: string){
    this.baseApiUrl += IndividualNumber.toString() + '&password='+password
    console.log(this.baseApiUrl)
    return this.http.get<Auth_Token>(`${this.baseApiUrl}`)
  }
}
