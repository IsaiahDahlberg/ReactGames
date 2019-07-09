import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>SimonWebAPI</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
               <LinkContainer to={'/'} exact>
                   <NavItem>
                      <Glyphicon glyph='home' /> Home
              </NavItem>
              </LinkContainer>
             <LinkContainer to={'/Simon'} exact>
               <NavItem>
                    <Glyphicon glyph='th-large' /> Simon
              </NavItem>
                </LinkContainer>
            <LinkContainer to={'/snake'}>
              <NavItem>
                  <Glyphicon glyph='random' /> Snake
              </NavItem>
             </LinkContainer>
             <LinkContainer to={'/blackjack'}>
                  <NavItem>
                            <Glyphicon glyph='usd' /> Black Jack
                 </NavItem>
              </LinkContainer>

          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
