import { Injectable } from '@angular/core';
import { SuperHeroes } from '../models/super-heroes';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SuperHeroService {
  private apiUrl = 'https://localhost:44329/api/SuperHero'

  constructor(private httpClient: HttpClient) { }

  getSuperHeroes(): Observable<SuperHeroes[]> {
    return this.httpClient.get<SuperHeroes[]>(this.apiUrl);
  }
  
  updateSuperHeroes(hero: SuperHeroes): Observable<SuperHeroes[]> {
    return this.httpClient.put<SuperHeroes[]>(this.apiUrl, hero);
  }
  
  createSuperHero(hero: SuperHeroes): Observable<SuperHeroes[]> {
    return this.httpClient.post<SuperHeroes[]>(this.apiUrl, hero);
  }

  deleteHero(hero: SuperHeroes): Observable<SuperHeroes[]> {
    return this.httpClient.delete<SuperHeroes[]>(`${this.apiUrl}/${hero.id}`);
  }
}   
