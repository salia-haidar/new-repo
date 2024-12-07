import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SuperHeroes } from '../../models/super-heroes';

@Component({
  selector: 'app-hero-modal',
  standalone: false,
  
  templateUrl: './hero-modal.component.html',
  styleUrl: './hero-modal.component.css'
})
export class HeroModalComponent {
  @Input () hero: SuperHeroes = new SuperHeroes();
  @Input () isOpen = false;
  @Input () isEditing = false;

  @Output () closeModal = new EventEmitter<void>();
  @Output () saveHero = new EventEmitter<SuperHeroes>();

  onCancel() {
    this.closeModal.emit();
  }

  onSave() {
    this.saveHero.emit(this.hero);
  }
}
