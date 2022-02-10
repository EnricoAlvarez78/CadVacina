import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IConfig, NgxMaskModule } from 'ngx-mask';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { ConsultaComponent } from './components/consulta/consulta.component';
import { DadosPessoaisComponent } from './components/cadastro/dados-pessoais/dados-pessoais.component';
import { EnderecoComponent } from './components/cadastro/endereco/endereco.component';
import { GrupoComponent } from './components/cadastro/grupo/grupo.component';
import { TituloAgendamentoComponent } from './templates/titulo-agendamento/titulo-agendamento.component';
import { BotoesAgendamentoComponent } from './templates/botoes-agendamento/botoes-agendamento.component';
import { DataVacinacaoComponent } from './components/cadastro/data-vacinacao/data-vacinacao.component';
import { PostoComponent } from './components/cadastro/posto/posto.component';
import { ResultadoComponent } from './components/shared/resultado/resultado.component';
import { AlertComponent } from './helpers/alert/alert.component';
import { SimpleModalModule } from 'ngx-simple-modal';
import { FooterComponent } from './templates/footer/footer.component';
import { HeaderComponent } from './templates/header/header.component';

const maskConfig: Partial<IConfig> = { validation: false };

@NgModule({
  declarations: [
    AppComponent,
    TituloAgendamentoComponent,
    DadosPessoaisComponent,
    HomeComponent,
    ConsultaComponent,
    EnderecoComponent,
    GrupoComponent,
    BotoesAgendamentoComponent,
    DataVacinacaoComponent,
    PostoComponent,
    ResultadoComponent,
    AlertComponent,
    FooterComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    NgxMaskModule.forRoot(maskConfig),
    HttpClientModule,
    SimpleModalModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
