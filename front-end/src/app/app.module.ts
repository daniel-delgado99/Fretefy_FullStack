import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeModule } from './modules/home/home.module';
import { ToolbarModule } from './components/toolbar/toolbar.module';
import { RouterModule } from '@angular/router';
import { RegiaoModule } from './modules/regiao/regiao.module';
import { RegiaoService } from './services/regiao.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    HomeModule,
    RegiaoModule,
    ToolbarModule,

    AppRoutingModule
  ],
  providers: [RegiaoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
