import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { JwtInterceptor } from './helpers/jwtInterceptor';
import { ErrorInterceptor } from './helpers/errorInterceptor';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './views/shareds/home/home.component';
import { LoginComponent } from './views/shareds/login/login.component';
import { IConfig, NgxMaskModule } from 'ngx-mask';
import { SimpleModalModule } from 'ngx-simple-modal';
import { NgxPaginationModule } from 'ngx-pagination';
import { ConfirmComponent } from './helpers/confirm/confirm.component';
import { AlertComponent } from './helpers/alert/alert.component';
import { GrupoFormComponent } from './components/administrador/grupo-crud/grupo-form/grupo-form.component';
import { GrupoGridComponent } from './components/administrador/grupo-crud/grupo-grid/grupo-grid.component';
import { PostoFormComponent } from './components/administrador/posto-crud/posto-form/posto-form.component';
import { PostoGridComponent } from './components/administrador/posto-crud/posto-grid/posto-grid.component';
import { UsuarioFormComponent } from './components/administrador/usuario-crud/usuario-form/usuario-form.component';
import { UsuarioGridComponent } from './components/administrador/usuario-crud/usuario-grid/usuario-grid.component';
import { AgendaFormComponent } from './components/gerente/agenda-crud/agenda-form/agenda-form.component';
import { AgendaGridComponent } from './components/gerente/agenda-crud/agenda-grid/agenda-grid.component';
import { LoteFormComponent } from './components/gerente/lote-crud/lote-form/lote-form.component';
import { LoteGridComponent } from './components/gerente/lote-crud/lote-grid/lote-grid.component';
import { RecepcionistaConsultaComponent } from './components/recepcionista/recepcionista-consulta/recepcionista-consulta.component';
import { RecepcionistaExibeComponent } from './components/recepcionista/recepcionista-exibe/recepcionista-exibe.component';
import { RecepcionistaFormComponent } from './components/recepcionista/recepcionista-form/recepcionista-form.component';
import { FooterComponent } from './templates/footer/footer.component';
import { HeaderComponent } from './templates/header/header.component';
import { NavComponent } from './templates/nav/nav.component';
import { GruposComponent } from './views/administrador/grupos/grupos.component';
import { PostosComponent } from './views/administrador/postos/postos.component';
import { UsuariosComponent } from './views/administrador/usuarios/usuarios.component';
import { AgendaComponent } from './views/gerente/agenda/agenda.component';
import { LotesComponent } from './views/gerente/lotes/lotes.component';
import { RelatoriosComponent } from './views/gerente/relatorios/relatorios.component';
import { RecepcaoComponent } from './views/recepcionista/recepcao/recepcao.component';
import { ChangePasswordComponent } from './views/shareds/change-password/change-password.component';
import { EsqueciSenhaComponent } from './views/shareds/esqueci-senha/esqueci-senha.component';
import { ErrorComponent } from './views/shareds/error/error.component';
import { ForbiddenErrorComponent } from './views/shareds/forbidden-error/forbidden-error.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';

const maskConfig: Partial<IConfig> = { validation: false,};

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        SimpleModalModule,
        NgxPaginationModule,
        NgxMaskModule.forRoot(maskConfig),
        NgxChartsModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        LoginComponent,
        ConfirmComponent,
        FooterComponent,
        HeaderComponent,
        NavComponent,
        UsuariosComponent,
        PostosComponent,
        GruposComponent,
        UsuarioFormComponent,
        UsuarioGridComponent,
        PostoFormComponent,
        PostoGridComponent,
        GrupoFormComponent,
        GrupoGridComponent,
        LotesComponent,
        AgendaComponent,
        RelatoriosComponent,
        AgendaFormComponent,
        RecepcaoComponent,
        AgendaFormComponent,
        AgendaGridComponent,
        LoteFormComponent,
        LoteGridComponent,
        RecepcionistaConsultaComponent,
        RecepcionistaFormComponent,
        RecepcionistaExibeComponent,
        ChangePasswordComponent,
        EsqueciSenhaComponent,
        ErrorComponent,
        ForbiddenErrorComponent
    ],
    entryComponents: [
      ConfirmComponent,
      AlertComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }


