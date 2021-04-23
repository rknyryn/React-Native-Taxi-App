import React, { Component } from "react";
import { Text, StyleSheet, View, FlatList } from "react-native";

export default class TypeOne_Third extends Component {
  constructor(prop) {
    super(prop);
    this.getData();
  }

  state = {
    data: "",
  };

  getData() {
    var requestOptions = {
      method: "GET",
      redirect: "follow",
    };

    fetch(
      "https://taxiappwebapi20210423191539.azurewebsites.net/api/TypeOne/GetThird",
      requestOptions
    )
      .then((response) => response.json())
      .then((result) => this.setState({ data: result }))
      .catch((error) => console.log("error", error));
  }

  render() {
    return (
      <View style={styles.container}>
        {this.state.data != null && (
          <FlatList
            keyExtractor={(item) => Math.random(0, 9999).toString()}
            data={this.state.data}
            renderItem={({ item }) => (
              <View style={styles.item}>
                <Text style={styles.text}>Tarih: {item.pickUpDatetime}</Text>
                <Text style={styles.text}>Mesafe: {item.tripDistance}mil</Text>
              </View>
            )}
          />
        )}
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#121212",
    padding: 10,
  },
  item: {
    marginTop: 5,
    padding: 20,
    backgroundColor: "#1E1E1E",
    borderRadius: 8,
    borderLeftColor: "#bb86fc",
    borderWidth: 2,
    width: "100%",
  },
  text: {
    fontSize: 18,
    color: "#E1E1E1",
  },
});
