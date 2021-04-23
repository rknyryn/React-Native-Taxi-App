import "react-native-gesture-handler";
import React from "react";
import { StyleSheet, Text, View, TouchableOpacity, StatusBar } from "react-native";
import { createStackNavigator } from "@react-navigation/stack";
import { NavigationContainer } from "@react-navigation/native";
import TypeOne_First from "./screens/typeOne/TypeOne_First";
import TypeOne_Third from "./screens/typeOne/TypeOne_Third";
import TypeTwo_Second from './screens/typeTwo/TypeTwo_Second';
import TypeTwo_Third from './screens/typeTwo/TypeTwo_Third';
import TypeThree_Third from './screens/typeThree/TypeThree_Third';

function Home({ navigation }) {
  return (
    <View style={styles.container}>
      <TouchableOpacity onPress={() => navigation.navigate("TypeOne_First")}>
        <Text style={styles.text}>Tip 1-1</Text>
      </TouchableOpacity>
      <TouchableOpacity onPress={() => navigation.navigate("TypeOne_Third")}>
        <Text style={styles.text}>Tip 1-3</Text>
      </TouchableOpacity>
      <TouchableOpacity onPress={() => navigation.navigate("TypeTwo_Second")}>
        <Text style={styles.text}>Tip 2-2</Text>
      </TouchableOpacity>
      <TouchableOpacity onPress={() => navigation.navigate("TypeTwo_Third")}>
        <Text style={styles.text}>Tip 2-3</Text>
      </TouchableOpacity>
      <TouchableOpacity onPress={() => navigation.navigate("TypeThree_Third")}>
        <Text style={styles.text}>Tip 3-3</Text>
      </TouchableOpacity>
      <StatusBar style="dark"/>
    </View>
  );
}

const Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator
        initialRouteName="Home"
        screenOptions={{
          headerStyle: { backgroundColor: "#1F1F1F" },
          headerTintColor: "#E1E1E1",
          headerTitleStyle: { fontWeight: "bold" },
        }}
      >
        <Stack.Screen
          options={{ title: "Home" }}
          name="Home"
          component={Home}
        />
        <Stack.Screen
          options={{ title: "Tip 1-1" }}
          name="TypeOne_First"
          component={TypeOne_First}
        />
        <Stack.Screen
          options={{ title: "Tip 1-3" }}
          name="TypeOne_Third"
          component={TypeOne_Third}
        />
        <Stack.Screen
          options={{ title: "Tip 2-2" }}
          name="TypeTwo_Second"
          component={TypeTwo_Second}
        />
        <Stack.Screen
          options={{ title: "Tip 2-3" }}
          name="TypeTwo_Third"
          component={TypeTwo_Third}
        />
        <Stack.Screen
          options={{ title: "Tip 3-3" }}
          name="TypeThree_Third"
          component={TypeThree_Third}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: "center",
    justifyContent: 'center',
    backgroundColor: '#121212',
  },
  text: {
    width: 200,
    fontSize: 16,
    padding: 20,
    marginTop: 10,
    fontWeight: "bold",
    color: "#E1E1E1",
    textAlign: "center",
    backgroundColor: '#1E1E1E',
    borderRadius: 8,
    borderBottomColor: '#bb86fc',
    borderWidth: 0.5,
  },
});
