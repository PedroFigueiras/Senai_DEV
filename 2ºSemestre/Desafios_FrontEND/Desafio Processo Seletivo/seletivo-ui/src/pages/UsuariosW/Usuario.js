import { Component } from "react";

class Usuarios extends Component{

    constructor(props){
      super(props);
      this.state = {
  
          listaUsuario : [],
          nomeRepositorio: '',
          nome_usuario: "",
          id_Repositorio: 0,
          descricao_Repositorio: "",
          data_Repositorio: "",
          tamanho_Repositorio: 0
  
      };
      };
       buscarR = (buscar) => {
          
        buscar.preventDefault();

        console.log("Repositório sendo buscado, um momento")

        fetch('https://api.github.com/users/' + this.state.nomeRepositorio + '/repos?per_page=10') 

        .then(resposta => resposta.json())
  
        .then(dados => this.setState({ listaRepositorios: dados }))
  
        .catch(erro => console.log(erro))

      };



      updateNome = async (user) => {
        await this.setState({ nomeRepositorio: user.target.value });
        console.log(this.state.nomeRepositorio)
      }

            // componentDidMount() {}
  
      render(){
        return(
          <div className="App">
            <main className="App" >
              { /*Lista de Usuario*/}
              <section className="App-header">
                <h2>Lista do Usuario</h2>
                <form onSubmit={this.buscarR}>
                    <div>
                         <input className="App-input" type="text" value={this.state.nomeRepositorio}   onChange={this.updateNome} placeholder="Nome de Usuario"/>
                        <button className="App-input" type="submit" onClick={this.buscarR }> Buscar </button>
                    </div>
                </form>
              </section>
              <section >
                  <table> 
                      <thead>
                        <tr>
                          <th># - </th>
                          <th>Nome Repositório - </th>
                          <th>Descrição do Repositório - </th>
                          <th>Data Criação - </th>
                          <th>Tamanho Repositório - </th>
                        </tr>
                      </thead>
      
                       <tbody>
                            {this.state.listaUsuario.map((repository) => {
                            return (
                              <tr key={repository.id}>
                                <td>{repository.id}</td>
                                <td>{repository.name}</td>
                                <td>{repository.description}</td>
                                <td>{repository.created_at}</td>
                                <td>{repository.size}</td>
                              </tr>
                            )
                          })
                          }
      
                      </tbody> 
                    </table>
              </section>  
            </main>
          </div>
        )
      }
  };

 
  
  
  export default Usuarios;