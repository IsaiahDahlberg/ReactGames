import React, { Component } from 'react';
import "./Simon.css";

function SimonButton(props) {
    var bgColor;
    if (props.active == props.id) {
        bgColor = props.colorActive;
    } else {
        bgColor = props.color;
    }
    return (
        <button className="simon-button" style={{ backgroundColor: bgColor }} onClick={props.onClick}>
        </button>
    )
}

class Board extends React.Component {
    constructor(props) {
        super(props);
        
    }

    render() {
        return (
            <div className="row">
                <div className="col-md-2" style={{ margin: 10 }}>             
                    <SimonButton color="darkgreen" colorActive="#00ff00" id="1" active={this.props.active} onClick={() => this.props.onClick(1)}/>
                    <SimonButton color="#808000" colorActive="#ffff33" id="4" active={this.props.active} onClick={() => this.props.onClick(4)}/>          
                </div>
                <div className="col-md-2" style={{ margin: 10 }} >
                    <SimonButton color="darkred" colorActive="red" id="2" active={this.props.active} onClick={() => this.props.onClick(2)}/>
                    <SimonButton color="#000066" colorActive="blue" id="3" active={this.props.active} onClick={() => this.props.onClick(3)}/>                 
                </div>
            </div>
        );
    }
}


export class Simon extends Component {
    displayName = Simon.name

    constructor(props) {
        super(props);
        this.state = {
            score: 0,
            index: 0,
            moveSet: [],
            activeColor: 0,
            awaitingClick: false,
            clicked: 0,
            correctCheck: 0,
        };
    }

    NewGame() {
        this.setState({ index: 0, score: 0 })
        fetch('api/Simon/newgame').then(response => response.json())
            .then(data => {
                this.setState({ moveSet: data });
                this.LoopMoveSet(0);
            });    
    }

    Round(color) {
        if (this.state.awaitingClick) {    
            this.checkColor(color).then(correct => {
                if (correct == 1) {
                    if (this.state.score === (this.state.index)) {
                        this.NewColor();
                        this.setState({ score: this.state.score + 1 });
                    }
                    this.setState({ index: this.state.index + 1 })
                } else {
                    this.setState({ index: 0 })
                    this.Lose(0, 0);
                }
            });
        }       
    }

    checkColor(color) {
       return fetch('api/Simon/Check/' + this.state.index + '/' + color)
            .then(response => response.json());
    }

    Lose(l, i) {
        this.setState({ awaitingClick: false })
        if (l >= 28) {     
            this.setState({ activeColor: 0 });
        } else {            
            if (i >= 5) {
                i = 1;                
            } else {
                i += 1;                
            }
            this.setState({ activeColor: i });
            l += 1
            setTimeout(() => { this.Lose(l, i) }, 100);
        }

    }

    NewColor() {
        fetch('api/Simon/Next');
        setTimeout(() => { this.RetrieveColors() }, 25); 
        setTimeout(() => { this.LoopMoveSet(0) }, 50);
    }

    RetrieveColors() {    
        fetch('api/Simon/Get')
            .then(response => response.json())
            .then(data => {
                this.setState({ moveSet: data});
            });              
    }

    LoopMoveSet(i) {        
        this.setState({ awaitingClick: false })
        if (this.state.moveSet.length == i || this.state.moveSet.length == 0) {
            this.setState({ activeColor: 0, index: 0 });
            this.setState({ awaitingClick: true })
        } else {
            this.setState({ activeColor: this.state.moveSet[i], index: i });
            setTimeout(() => { this.LoopTimer() }, 400);      
        }            
    }

    LoopTimer() {    
        this.setState({ activeColor: 0 });
        setTimeout(() => { this.LoopMoveSet(this.state.index + 1) }, 100);
    }

    handleClick(i) {
        this.setState({ clicked: i });
        this.Round(i);
    }

    render() {
        return (
            <div>
                <h4>Score: {this.state.score} </h4>       
                <h1>Simon</h1>              
                <Board active={this.state.activeColor} onClick={i => this.handleClick(i)} />
                <button onClick={()=>this.NewGame()}> New Game</button>
            </div>
        );
    }
}