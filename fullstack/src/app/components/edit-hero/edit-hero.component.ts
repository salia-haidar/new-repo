import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SuperHeroes } from '../../models/super-heroes';
import { FormsModule } from '@angular/forms';
import { SuperHeroService } from '../../services/super-hero.service';

@Component({
  selector: 'app-edit-hero',
  standalone: false,
  templateUrl: './edit-hero.component.html',
  styleUrl: './edit-hero.component.css'
})
export class EditHeroComponent implements OnInit {
  @Input () hero?: SuperHeroes; 
  @Output () heroesUpdated = new EventEmitter<SuperHeroes[]> (); 

  constructor(private superHeroService: SuperHeroService) {

  }
  ngOnInit(): void {
  }

  updateHero(hero:SuperHeroes){
    this.superHeroService.updateSuperHeroes(hero)
    .subscribe((heroes: SuperHeroes[]) => {
      this.heroesUpdated.emit(heroes)
    })
  }
  deleteHero(hero:SuperHeroes){
    this.superHeroService
    .deleteHero(hero)
    .subscribe((heroes: SuperHeroes[]) => {
      this.heroesUpdated.emit(heroes)
    })
  }
  createHero(hero:SuperHeroes){
    this.superHeroService
    .createSuperHero(hero)
    .subscribe((heroes: SuperHeroes[]) => {
      this.heroesUpdated.emit(heroes)
    })
  }
}
