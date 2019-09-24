import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component'
import { StrandFormComponent } from './strand-form/strand-form.component'
import { StrandListComponent } from './strand-list/strand-list.component'
import { StrandDetailsComponent } from './strand-details/strand-details.component'
import { AuthGuard } from './_helpers';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'strandform', component: StrandFormComponent },
  { path: 'strands', component: StrandListComponent },
  { path: 'strands/:id', component: StrandDetailsComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
