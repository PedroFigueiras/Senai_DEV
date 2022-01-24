import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {

    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: ''
        };
    }

       efetuarLogin = async() => {
        const resposta = await api.post('/Login',{
            email: this.state.email,
            senha: this.state.senha,
        })

        const token = resposta.data.token;
        await AsyncStorage.setItem('Token',token);

        if (resposta.status === 200) {
            console.warn(token)
            this.props.navigation.navigate('ListarM')          
        }
        } 

    render() {
        return (
            <ImageBackground
                source={require('../../assets/login.png')}
                style={StyleSheet.absoluteFillObject}
            >
                <View style={styles.container}>
                    <Text style={styles.loginn}>LOGIN</Text>
                    <TextInput
                    placeholder="EMAIL"
                    placeholderTextColor="#9C9C9C"
                    keyboardType="email-address"
                    style={styles.emaill}
                    onChangeText={email => this.setState({email}) }
                    />
                    <TextInput
                    placeholder="SENHA"
                    placeholderTextColor="#9C9C9C"
                    keyboardType="default"
                    secureTextEntry={true}
                    style={styles.senhaa}
                    onChangeText={senha => this.setState({senha}) }
                    />
                    <TouchableOpacity
                    style={styles.bLogin}
                    onPress={this.efetuarLogin}
                    >
                        <Text style={styles.btnText}>Login</Text>
                    </TouchableOpacity>

                   
                </View>

            </ImageBackground>


        )
    }

}

const styles = StyleSheet.create({

    container: { 
        flex: 1,
        alignItems: 'center',
        justifyContent: 'center',
     },
     emaill:{
         backgroundColor:'white',
         width:300,
         borderRadius:20,
         height:35,
         padding:10,
         alignItems:'flex-start',
         fontSize:14,
         marginTop:60,
         marginBottom:32,
         justifyContent:'flex-start'
     },
     senhaa:{
         backgroundColor:'white',
         width:300,
         padding:10,
         alignItems:'center',
         fontSize:14,
         marginBottom:34,
         borderRadius:20,
         height:35,

     },


     bLogin:{
         backgroundColor:'#3582FF',
         width:80,
         height:40,
         borderRadius:60,
        alignItems:'center',
       justifyContent:'center'
     },

     btnText:{
        color:'white',
        
     },

     loginn:{

        fontSize: 34,
        lineHeight: 39,
        color: "white",

     } 

})