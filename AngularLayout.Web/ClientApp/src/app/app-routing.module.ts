import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ValueListComponent } from './pages/general/value-list/value-list.component';
import { HomeComponent } from './pages/common/home/home.component';
import { DashboardTestComponent } from './pages/test/dashboard-test/dashboard-test.component';
import { DragDropTestComponent } from './pages/test/drag-drop-test/drag-drop-test.component';
import { FormTestComponent } from './pages/test/form-test/form-test.component';
import { TableTestComponent } from './pages/test/table-test/table-test.component';
import { TreeTestComponent } from './pages/test/tree-test/tree-test.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'general/value-list', component: ValueListComponent },
  { path: 'test/dashboard', component: DashboardTestComponent },
  { path: 'test/drag-drop', component: DragDropTestComponent },
  { path: 'test/form', component: FormTestComponent },
  { path: 'test/table', component: TableTestComponent },
  { path: 'test/tree', component: TreeTestComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
