import React, { Component } from 'react';
import "./Snake.css";

export class Snake extends React.Component {
    constructor() {
        super();
        this.state = {
            grid: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,]
        }
    }

    newGame() {
        fetch('api/snake/newgame').then(()=> 
        fetch('api/snake/GetCoords').then(response => response.json())
            .then(data => { this.setState({ grid: data }) }));
    }


    createGrid(grid) {
        var returngrid = "";
        for (var i = 100; i >= 1; i--) {
            if (i % 10 == 0) {
                returngrid += ("\n \r");
            }
            returngrid += (grid[i-1] + " ");

        }
        return returngrid;
    }
    move(d) {
        fetch('api/snake/move/' + d).then(response => response.json())
            .then(data => { this.setState({ grid: data }) });
    }

    fireKey = e => {
        if (e.key == 'w') {
            this.move(1);
        } else if (e.key == 'd') {
            this.move(2);
        } else if (e.key == 's') {
            this.move(3);
        } else if (e.key == 'a') {
            this.move(4);
        }
    }

    render() {
        
        return (
            <div onKeyPress={this.fireKey}>                
                <button onClick={i =>this.newGame() }>New game</button>
                <div className="grid"> {this.createGrid(this.state.grid)} </div>
            </div>
        );
    }

}

