import { UserProfilePageComponent } from './Pages/user-profile-page/user-profile-page.component';
import { Routes } from '@angular/router';
import { LoginPageComponent } from './Pages/login-page/login-page.component';
import { ProfileEditPageComponent } from './Pages/profile-edit-page/profile-edit-page.component';
import { TaskEndPageComponent } from './Pages/task-end-page/task-end-page.component';

export const routes: Routes = [
  {path: '',component:LoginPageComponent},
  {path: 'userProfile',component: UserProfilePageComponent},
  {path: 'userProfile/pforileEdit', component: ProfileEditPageComponent},
  {path: 'userTasks/taskEnd', component: TaskEndPageComponent}
];
