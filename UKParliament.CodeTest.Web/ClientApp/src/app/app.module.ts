import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { PeopleComponent } from './components/people/people.component';
import { PersonComponent } from './components/person/person.component';

@NgModule({ declarations: [
        AppComponent,
        PeopleComponent,
        PersonComponent
    ],
  bootstrap: [AppComponent], imports: [ReactiveFormsModule, MatTableModule, MatPaginatorModule, MatSortModule, BrowserAnimationsModule, BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        FormsModule,
        RouterModule.forRoot([
          { path: '', component: PeopleComponent, pathMatch: 'full' }
        ])], providers: [provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }
