import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormsModule, FormGroup, Validators } from '@angular/forms';
import { PersonViewModel } from '../../models/person-view-model';
import { DepartmentViewModel } from '../../models/department-view-model';

@Component({
  selector: 'app-person-edit',
  templateUrl: './person.component.html',
  styleUrl: './person.component.scss'
})

/* This component is responsible for displaying and editing a person's details.
*/ 
export class PersonComponent implements OnChanges {

  @Input() person!: PersonViewModel;
  @Input() departments: DepartmentViewModel[] = [];
  @Output() save = new EventEmitter<PersonViewModel>();
  @Output() cancel = new EventEmitter<void>();

  editedPerson: any = {};

  // Form group for the person edit form
  ngOnChanges(changes: SimpleChanges) {
    if (changes['person'] && changes['person'].currentValue) {
      this.editedPerson = { ...changes['person'].currentValue };
    }
  }

  // Form controls for the person edit form. Event sent back to parent (people control) which will initate the validate/save
  onSave() {
    this.save.emit(this.editedPerson);
  }

  // Event sent back to parent (people control) which will close the edit form
  onCancel() {
    this.cancel.emit();
  }

}
