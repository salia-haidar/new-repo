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
  
  isModalOpen = false;
  isEditing = false;
  currentHero : SuperHeroes = new SuperHeroes();

  constructor(private hiroService: SuperHeroService) {}

  ngOnInit(): void {
    this.loadHeroes();  
  }

  loadHeroes() {
    this.hiroService.getSuperHeroes().subscribe(
      (res: SuperHeroes[]) => {
        this.hiroes = res;
      }
    );
  }
  openCreateModal() {
    this.currentHero = new SuperHeroes();
    this.isEditing = false;
    this.isModalOpen = true;
  }
  openEditModal(hero: SuperHeroes) {
    this.currentHero = {...hero};
    this.isEditing = true;
    this.isModalOpen = true;
  }
  closeModal() {
    this.isModalOpen = false;
    this.currentHero = new SuperHeroes();
  }
  saveHero(hero: SuperHeroes) {
    if(this.isEditing){
      this.updateHero(hero);
    }else{
      this.createHero(hero);
    }
  }
  createHero(hero:SuperHeroes) {
    this.hiroService.createSuperHero(hero).subscribe(
      (updatedHeroes: SuperHeroes[]) => {
        this.hiroes = updatedHeroes;
        this.closeModal();
      }
    );
  }
  updateHero(hero: SuperHeroes) {
    this.hiroService.updateSuperHeroes(hero).subscribe(
      (updatedHeroes: SuperHeroes[]) => {
        this.hiroes = updatedHeroes;
        this.closeModal();
      }
    );
  }
  deleteHero(hero: SuperHeroes){
    this.hiroService.deleteHero(hero).subscribe(
      (updatedHeroes: SuperHeroes[]) => {
        this.hiroes = updatedHeroes;
      }
    );
  }
 }
