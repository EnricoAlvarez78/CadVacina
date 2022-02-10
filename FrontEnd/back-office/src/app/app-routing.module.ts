import { ForbiddenErrorComponent } from './views/shareds/forbidden-error/forbidden-error.component';
import { ErrorComponent } from './views/shareds/error/error.component';
import { EsqueciSenhaComponent } from './views/shareds/esqueci-senha/esqueci-senha.component';
import { ChangePasswordComponent } from './views/shareds/change-password/change-password.component';
import { RecepcionistaExibeComponent } from './components/recepcionista/recepcionista-exibe/recepcionista-exibe.component';
import { RecepcionistaFormComponent } from './components/recepcionista/recepcionista-form/recepcionista-form.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GrupoFormComponent } from './components/administrador/grupo-crud/grupo-form/grupo-form.component';
import { PostoFormComponent } from './components/administrador/posto-crud/posto-form/posto-form.component';
import { UsuarioFormComponent } from './components/administrador/usuario-crud/usuario-form/usuario-form.component';
import { AgendaFormComponent } from './components/gerente/agenda-crud/agenda-form/agenda-form.component';
import { LoteFormComponent } from './components/gerente/lote-crud/lote-form/lote-form.component';
import { RecepcionistaConsultaComponent } from './components/recepcionista/recepcionista-consulta/recepcionista-consulta.component';
import { AuthGuard } from './helpers/authGuard';
import { GruposComponent } from './views/administrador/grupos/grupos.component';
import { PostosComponent } from './views/administrador/postos/postos.component';
import { UsuariosComponent } from './views/administrador/usuarios/usuarios.component';
import { AgendaComponent } from './views/gerente/agenda/agenda.component';
import { LotesComponent } from './views/gerente/lotes/lotes.component';
import { RelatoriosComponent } from './views/gerente/relatorios/relatorios.component';
import { RecepcaoComponent } from './views/recepcionista/recepcao/recepcao.component';
import { HomeComponent } from './views/shareds/home/home.component';
import { LoginComponent } from './views/shareds/login/login.component';

const routes: Routes = [
    { path: 'login', component: LoginComponent},
    { path: 'esqueci-senha', component: EsqueciSenhaComponent},
    { path: 'error', component: ErrorComponent},
    { path: 'forbidden-error', component: ForbiddenErrorComponent},
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'home', component:HomeComponent, canActivate: [AuthGuard] },
    { path: 'usuarios', component:UsuariosComponent, canActivate: [AuthGuard] },
    { path: 'usuarios/form', component:UsuarioFormComponent, canActivate: [AuthGuard] },
    { path: 'usuarios/form/:id', component:UsuarioFormComponent, canActivate: [AuthGuard] },
    { path: 'postos', component:PostosComponent, canActivate: [AuthGuard] },
    { path: 'postos/form', component:PostoFormComponent, canActivate: [AuthGuard] },
    { path: 'postos/form/:id', component:PostoFormComponent, canActivate: [AuthGuard] },
    { path: 'grupos', component:GruposComponent, canActivate: [AuthGuard] },
    { path: 'grupos/form', component:GrupoFormComponent, canActivate: [AuthGuard] },
    { path: 'grupos/form/:id', component:GrupoFormComponent, canActivate: [AuthGuard] },
    { path: 'agendas', component:AgendaComponent, canActivate: [AuthGuard] },
    { path: 'agendas/form', component:AgendaFormComponent, canActivate: [AuthGuard] },
    { path: 'agendas/form/:id', component:AgendaFormComponent, canActivate: [AuthGuard] },
    { path: 'lotes', component:LotesComponent, canActivate: [AuthGuard] },
    { path: 'lotes/form', component:LoteFormComponent, canActivate: [AuthGuard] },
    { path: 'lotes/form/:id', component:LoteFormComponent, canActivate: [AuthGuard] },
    { path: 'relatorios', component:RelatoriosComponent, canActivate: [AuthGuard] },
    { path: 'recepcao', component:RecepcaoComponent, canActivate: [AuthGuard] },
    { path: 'consulta', component:RecepcionistaConsultaComponent, canActivate: [AuthGuard] },
    { path: 'confirmarDados/:cpf', component:RecepcionistaFormComponent, canActivate: [AuthGuard] },
    { path: 'exibeDados/:cpf', component:RecepcionistaExibeComponent, canActivate: [AuthGuard] },
    { path: 'changepassword', component:ChangePasswordComponent, canActivate: [AuthGuard] }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
