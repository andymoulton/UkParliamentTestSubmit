import { Component, NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { DepartmentService } from '../../services/department.service';
import { PersonViewModel } from '../../models/person-view-model';
import { DepartmentViewModel } from '../../models/department-view-model';

@Component({
  selector: 'app-people-list',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent {

  error: string = '';
  person?: PersonViewModel;
  people: PersonViewModel[] = [];
  departments: DepartmentViewModel[] = [];

  personBeingEdited: any = null;

  displayedColumns: string[] = [
    'firstName',
    'lastName',
    'email',
    'dateOfBirth',
    'departmentId'
  ];

  constructor(
    private personService: PersonService,
    private departmentService: DepartmentService
  ) {
    this.getAllPeople();
    this.getAllDepartments();
  }

  getPersonById(id: number): void {
    this.personService.getById(id).subscribe({
      next: (result) => {
        this.person = result;
      },
      error: (e) => { this.error = `Error: ${e}`; }
    });
  }

  getAllPeople(): void {
    this.personService.getAll().subscribe({
      next: (result) => {
        this.people= result;
      },
      error: (e) => { this.error = `Error: ${e}`; }
    });
  }

  editPerson(person: any) {
    this.personBeingEdited = person;
  }

  deletePerson(person: any) {
    const index = this.people.findIndex(p => p.id === person.id);
    if (index !== -1) {
      this.people.splice(index, 1);
    }
  }
   
  getAllDepartments(): void {
    this.departmentService.getAll().subscribe({
      next: (result) => {
        this.departments = result;
      },
      error: (e) => { this.error = `Error: ${e}`; }
    });
  }

  cancelEdit() {
    this.personBeingEdited = null;
  }

  savePerson(updatedPerson: any) {
    // Update the person in the list
    const index = this.people.findIndex(p => p.id === updatedPerson.id);
    if (index !== -1) {
      this.people[index] = updatedPerson;
    }
    this.personBeingEdited = null;
  }


}
