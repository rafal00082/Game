import { Component, OnInit } from '@angular/core';
import { pid } from 'process';
import { Observable, pipe } from 'rxjs';
import { Player } from 'src/app/player/models/player.model';
import { PlayersKindItem } from '../models/playerkinditem.model';
import { PlayService } from '../services/play.service';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {

  player1: Player = new Player();
  player2: Player = new Player();
  playersKindItems$: Observable<PlayersKindItem[]>;
  selection = '1';


  constructor(private playService: PlayService) { }

  ngOnInit(): void {
    this.playersKindItems$ = this.getPlyersKindItems();
    this.play();
  }

  onClick(): void {
    this.play();
  }

  play(): void {
    this.playService.play(this.selection).subscribe((results) => {
      if (results && results.length > 1) {
        this.player1 = results[0];
        this.player2 = results[1];
      }
    });
  }
  getPlyersKindItems(): Observable<PlayersKindItem[]>{
   return this.playService.getPlayersKindItems();
  }

}
