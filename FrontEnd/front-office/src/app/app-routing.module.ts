import { ConsultaComponent } from './components/consulta/consulta.component';

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DataVacinacaoComponent } from './components/cadastro/data-vacinacao/data-vacinacao.component';
import { EnderecoComponent } from './components/cadastro/endereco/endereco.component';
import { DadosPessoaisComponent } from './components/cadastro/dados-pessoais/dados-pessoais.component';
import { HomeComponent } from './components/home/home.component';
import { GrupoComponent } from './components/cadastro/grupo/grupo.component';
import { PostoComponent } from './components/cadastro/posto/posto.component';
import { ResultadoComponent } from './components/shared/resultado/resultado.component';

const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'home', component: HomeComponent},
  { path: 'dadosPessoais', component: DadosPessoaisComponent},
  { path: 'endereco', component: EnderecoComponent},
  { path: 'grupo', component: GrupoComponent},
  { path: 'dataVacinacao', component: DataVacinacaoComponent},
  { path: 'posto', component: PostoComponent},
  { path: 'resultado', component: ResultadoComponent},
  { path: 'consulta', component: ConsultaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
