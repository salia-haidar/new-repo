import { Component } from '@angular/core';
import { SuperHeroes } from './models/super-heroes';
import { SuperHeroService } from './services/super-hero.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'This is full-stack Yo !!';
  hiroes: SuperHeroes[] = []
  heroToEdit!: SuperHeroes;

  constructor(private hiroService: SuperHeroService) {}

  ngOnInit(): void {
    this.hiroService.getSuperHeroes().subscribe((res: SuperHeroes[]) => {
      this.hiroes = res;
    });
  }

  updateHeroList(herows: SuperHeroes[]){
    this.hiroes = herows;
  }

  initNewHero(){
    this.heroToEdit = new SuperHeroes();
  }  

  editHero(hiro: SuperHeroes){
    this.heroToEdit = hiro;
  }
  
 }
