import { Injectable } from '@angular/core';
import { Player } from 'src/app/player/models/player.model';
import { environment } from 'src/environments/environment';

import { HttpClient } from '../../../../node_modules/@angular/common/http';
import { Observable } from '../../../../node_modules/rxjs';


@Injectable({
  providedIn: 'root'
})
export class PlayService {

  constructor(private http: HttpClient) {}

  play = (kind: string): Observable<Player[]> => {
    return this.http.get<Player[]>(environment.apiAdress + 'play/' + kind);
  }
}