import { Component, NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { DepartmentService } from '../../services/department.service';
import { PersonViewModel } from '../../models/person-view-model';
import { DepartmentViewModel } from '../../models/department-view-model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ViewChild } from '@angular/core';

@Component({
  selector: 'app-people-list',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})

/* This component is responsible for displaying a list of people, allowing for editing and deleting of person records.
    It uses Angular Material components for the table, paginator, and sort functionality.
*/

export class PeopleComponent {

  dataSource = new MatTableDataSource<PersonViewModel>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  error: string = '';
  message: string = '';
  person?: PersonViewModel;
  people: PersonViewModel[] = [];
  departments: DepartmentViewModel[] = [];
  personBeingEdited: any = null;
  displayedColumns: string[] = [
    'id',
    'firstName',
    'lastName',
    'dateOfBirth',
    'departmentName',
    'actions'
  ];

  constructor(
    private personService: PersonService,
    private departmentService: DepartmentService
  ) {
    this.getAllPeople();
    this.getAllDepartments();
  }

  // Lifecycle hook to set up the data source after the view has been initialized
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  // Method to get a person by ID
  getPersonById(id: number): void {
    this.personService.getById(id).subscribe({
      next: (result) => {
        this.person = result;
      },
      error: (e) => { this.error = `Error: ${e}`; }
    });
  }

  // Method to get all people
  getAllPeople(): void {
    this.personService.getAll().subscribe({
      next: (result) => {
        this.dataSource.data = result;

      },
      error: (e) => { this.error = `Error: ${e}`; }
    });
  }

  // Method to set edited person as a new instance. This will cause the modal dialog to appear with blank fields.
  addPerson() {
    this.personBeingEdited = {
      id: -1,
      firstName: '',
      lastName: '',
      email: '',
      dateOfBirth: '2000-01-01',
      departmentId: undefined
    } as unknown;
  }

  // Method to edit a person (initiates editing mode). This will cause the modal dialog to appear with blank fields.
  editPerson(person: any) {
    this.personBeingEdited = person;
  }

  // Method to delete a person
  deletePerson(person: any) {
    const confirmed = confirm(`Are you sure you want to delete ${person.firstName} ${person.lastName}?`);
    if (!confirmed) {
      return;
    }
    this.dataSource.data = this.dataSource.data.filter(p => p.id !== person.id);
    this.dataSource.data = [...this.dataSource.data];
  }
   
  // Method to get all departments
  getAllDepartments(): void {
    this.departmentService.getAll().subscribe({
      next: (result) => {
        this.departments = result;
      },
      error: (e) => { this.error = `Error: ${e}`; }
    });
  }

  // Method to cancel editing a person
  cancelEdit() {
    this.personBeingEdited = null;
  }

  // Method to save the edited person. Validation is done server side, an exception is raise if there are issues.
  savePerson(updatedPerson: any) {
    
    if (!updatedPerson || !updatedPerson.id) {
      this.error = 'Invalid person data';
      return;
    }

    this.personService.save(updatedPerson).subscribe({
      next: (result) => {
        const index = this.dataSource.data.findIndex(p => p.id === updatedPerson.id);
        if (index !== -1) {
          this.dataSource.data[index] = updatedPerson;
          updatedPerson.departmentName = this.departments.find(d => d.id === updatedPerson.departmentId)?.name || '';
        }
        else {
          updatedPerson.id = Math.max(...this.dataSource.data.map(p => p.id), 0) + 1; // get the next id
          updatedPerson.departmentName = this.departments.find(d => d.id === updatedPerson.departmentId)?.name || '';
          this.dataSource.data.push(updatedPerson);
        }
        this.dataSource.data = [...this.dataSource.data]; // trigger change in mat-table
        this.personBeingEdited = null;
        this.error = '';
        this.showMessage('Employee details have been updated successfully.');
      },
      error: (e) => { this.error = `Error: ${e.error}`; this.message = ''; }
    });

  }

  closeError() {
    this.error = '';
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  private showMessage(msg: string) {
    this.message = msg;
    setTimeout(() => {
      this.message = '';
    }, 3000);
  }

}


