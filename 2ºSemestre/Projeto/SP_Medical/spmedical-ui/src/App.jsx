import './App.css';
import logo from '../src/assets/img/Logo.png'
import Ilogo from '../src/assets/img/imagem login.png'
import Isp from '../src/assets/img/spmedical.png'
import { Component } from 'react';
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from './token.js/tiken.js';
// import { Link } from 'react-router-dom';

export default class App extends Component {

  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
      erroMensagem: '',
      isLoading: false,
    };
  }

  efetuaLogin = (event) => {
    event.preventDefault();
    console.log('logando')
    this.setState({ erroMensagem: '', isLoading: true });

    // axios.post('http://192.168.18.9:5000/api/Login', {
    //   email: this.state.email,
    //   senha: this.state.senha,
    // })

    axios.post('http://192.168.18.9:5000/api/Login', {
      email: this.state.email,
      senha: this.state.senha,
    })

      .then((resposta) => {
        if (resposta.status === 200) {

          localStorage.setItem('usuario-login', resposta.data.token);
          this.setState({ isLoading: false })

          let base64 = localStorage.getItem('usuario-login').split('.')[1];


          console.log(base64)

          if (parseJwt().role === '1') {

            this.props.history.push('/listarconsulta');
            console.log('logado: ' + usuarioAutenticado());
          } else if (parseJwt().role === '2') {
            this.props.history.push('/listarmedicos');
          } else {
            this.props.history.push('/listarminhas');
          }
        }
      })

      .catch(() => {
        this.setState({
          erroMensagem: 'E-mail ou senha inválidos, corrija NOVAMENTE',
          isLoading: false,
        });
      });

  }

  atualizaStateCampo = (campo) => {
    this.setState({ [campo.target.name]: campo.target.value });
  };


  render() {
    return (
      <div className="App">
        <header className="App-header">
          <div className="divisao">
            <img className="img" src={Ilogo} alt="" />
            <div className="quadro_azul">
              <div>
                <img className="logo" src={logo} alt="" />
                <h1 className="h1">LOGIN</h1>
              </div>
              <div >
                <form onSubmit={this.efetuaLogin}>
                  <div className="input">
                    <label className="label" htmlFor="email">Email</label>
                    <input value={this.state.email}
                      onChange={this.atualizaStateCampo}
                      type="email"
                      name="email"
                    />
                  </div>
                  <div className="input">

                    <label className="label" htmlFor="senha">Senha</label>
                    <input value={this.state.senha}
                      onChange={this.atualizaStateCampo}
                      type="password"
                      name="senha" />

                  </div>

                  <div >

                    {
                      this.state.isLoading === true && <button className="brlogin" id="btn-login"> Loading </button>
                    }

                    {
                      this.state.isLoading === false && <button className="brlogin" id="btn-login" type="submit"
                        disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''} >
                        Logar
                      </button>
                    }

                  </div>

                </form>
              </div>

            </div>
          </div>
        </header>
      </div>
    );
  }

}

