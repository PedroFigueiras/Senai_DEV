import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
    FlatList,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class ListarM extends Component {

    constructor(props) {
        super(props);
        this.state = {
            listaMinhasConsultas: []
        };
    }

    buscarConsultas = async () => {
        try {
            const token = await AsyncStorage.getItem('Token');
            if (token != null) {

                const resposta = await api.get('/Consultas/medico', {
                    headers: {
                        Authorization: 'Bearer ' + token,
                    },
                });

                if (resposta.status === 200) {

                    this.setState({ listaMinhasConsultas: resposta.data })

                }

            }

        } catch (error) {
            console.warn(error)

        }
    }

    componentDidMount() {
        this.buscarConsultas();
    }


    realizarLogout = async () => {
        try {
            await AsyncStorage.removeItem('Token');
            this.props.navigation.navigate('Login');
        } catch (error) {
            console.warn(error);
        }
    };


    render() {
        return (

            <View style={styles.fundao}>
                <ImageBackground />
                {/* <Image style={styles.logo} source={require('../../assets/fundo.png')} /> */}
                <FlatList

                    ListHeaderComponent={
                        <>
                            <View style={styles.volta}>
                                <TouchableOpacity
                                    style={styles.sairr}
                                    onPress={this.realizarLogout}>

                                    <Text style={styles.textsair} >Sair</Text>
                                </TouchableOpacity>

                            </View>
                            
                            <View style={styles.minhas}>

                                <Text style={styles.textMC}>Minhas Consultas</Text>
                            </View>
                        </>
                    }

                    contentContainerStyle={styles.mainBodyContent}
                    data={this.state.listaMinhasConsultas}
                    keyExtractor={item => item.idConsulta}
                    renderItem={this.renderItem}


                />
            </View>

        )
    }

    renderItem = ({ item }) => (
        <View style={styles.laranjao}>
            <View style={styles.brancaoo}>
                <Text style={styles.listao}>Médico: {(item.idMedicoNavigation.nomeMedico)}</Text>
                <Text style={styles.listao}>Paciente: {(item.idPacienteNavigation.nomePaciente)}</Text>
                <Text style={styles.listao}>
                    Data e Horario:
                    {Intl.DateTimeFormat("pt-BR", {
                        year: 'numeric', month: 'short', day: 'numeric',
                        hour: 'numeric', minute: 'numeric', hour12: true
                    }).format(new Date(item.dataHora))}
                </Text>

                <Text style={styles.listao}>Especialidade: {(item.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade)}</Text>
                <Text style={styles.listao} >Descrição: {item.descricao}</Text>
            </View>

        </View>


    )
}
const styles = StyleSheet.create({

    fundao: {
        backgroundColor: "#9FDF6A"
    },

    laranjao: {

        backgroundColor: 'orange',
        marginBottom: 20,
        borderRadius: 50,
        marginTop: 20,
        height: 240,
        width:320,
        paddingTop: 13,
        paddingRight: 50,
        paddingLeft: 50,
        justifyContent: 'center',
        alignItems: 'center',
        

    },

    brancaoo: {

        backgroundColor: '#187D99',
        height: 220,
        width: 300,
        borderRadius: 50,
        marginBottom: 16,
        padding: 15,        


    },

    titulo: {
        alignItems: 'center',
        justifyContent: 'center',
        flexDirection: 'row',
        marginTop: 6
    },

    

    volta:{
        backgroundColor: '#187D99',
        borderRadius: 100,
        height: 50,
        width: 100,
        marginLeft: 100,
    },

    sairr: {
        alignItems: 'center',
        justifyContent: 'center',
        flexDirection: 'row',
        marginTop: 15,
        
    },

    textsair: {
        fontSize: 18,
        marginLeft: 2,
        color: "white",

    },

    minhas: {
        alignItems: 'center',
        justifyContent: 'center',
        marginTop: 50

    },

    mainBodyContent: {
        paddingTop: 30,
        paddingRight: 50,
        paddingLeft: 50,

    },

    listao: {
        marginTop: 10,
        color: 'white',

    },

    
})
