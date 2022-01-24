import 'react-native-gesture-handler';

import React from 'react';

import {NavigationContainer} from '@react-navigation/native';
import {createStackNavigator} from '@react-navigation/stack';
import Login from '../spMobile/src/screens/login';
import ListarM from './src/screens/listarM';
import ListarP from './src/screens/listarP';

const AuthStack = createStackNavigator();

export default function Stack() {
  return (
    <NavigationContainer>
      {/* <StatusBar
        hidden={true}
      /> */}

      <AuthStack.Navigator
        initialRouteName="Login"
        screenOptions={{
          headerShown: false,
        }}
        >
        <AuthStack.Screen name="Login" component={Login} />
        <AuthStack.Screen name="ListarM" component={ListarM} />
        <AuthStack.Screen name="ListarP" component={ListarP} />
      </AuthStack.Navigator>
    </NavigationContainer>
  );
}
