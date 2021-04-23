import React, { Component } from "react";
import { Text, StyleSheet, View } from "react-native";
import MapView, { Marker, PROVIDER_GOOGLE } from "react-native-maps";
import MapViewDirections from "react-native-maps-directions";

export default class TypeThree_Third extends Component {
  constructor(props) {
    super(props);
    this.state = {
      originShort: {},
      destinationShort: {},
      originLong: {},
      destinationLong: {},
      originShortName: "",
      destinationShortName: "",
      originLongName: "",
      destinationLongName: "",
      show: false,
      GOOGLE_MAPS_APIKEY: "AIzaSyCOA7g0o-KcAnxg7C_d74h8quV_Ffsc4Ng",
    };
  }

  componentDidMount() {
    this.getData();
  }

  getData() {
    var requestOptions = {
      method: "GET",
      redirect: "follow",
    };

    fetch(
      "https://taxiappwebapi20210423191539.azurewebsites.net/api/TypeThree/GetThird",
      requestOptions
    )
      .then((response) => response.json())
      .then((result) => {
        this.setState({
          originShort: result.shortRoute.puLocationCoordinate,
          destinationShort: result.shortRoute.doLocationCoordinate,
          originLong: result.longRoute.puLocationCoordinate,
          destinationLong: result.longRoute.doLocationCoordinate,
          destinationShortName: result.shortRoute.doLocation,
          originShortName: result.shortRoute.puLocation,
          destinationLongName: result.longRoute.doLocation,
          originLongName: result.longRoute.puLocation,
          show: true,
        });
      })
      .catch((error) => console.log("error", error));
  }

  render() {
    return (
      <View style={styles.container}>
        <MapView
          style={{ width: "100%", height: "100%" }}
          provider={PROVIDER_GOOGLE}
        >
          {this.state.show && (
            <View>
              <MapViewDirections
                origin={this.state.originShort}
                destination={this.state.destinationShort}
                apikey={this.state.GOOGLE_MAPS_APIKEY}
                strokeWidth={3}
                strokeColor="red"
              />
              <MapViewDirections
                origin={this.state.originLong}
                destination={this.state.destinationLong}
                apikey={this.state.GOOGLE_MAPS_APIKEY}
                strokeWidth={3}
                strokeColor="blue"
              />
              <Marker
                pinColor={"red"}
                coordinate={this.state.originShort}
                title={"Başlangıç"}
                description={this.state.originShortName}
              />
              <Marker
                pinColor={"red"}
                coordinate={this.state.destinationShort}
                title={"Bitiş"}
                description={this.state.destinationShortName}
              />
              <Marker
                pinColor={"red"}
                coordinate={this.state.originLong}
                title={"Başlangıç"}
                description={this.state.originLongName}
              />
              <Marker
                pinColor={"red"}
                coordinate={this.state.destinationLong}
                title={"Bitiş"}
                description={this.state.destinationLongName}
              />
            </View>
          )}
        </MapView>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#121212",
    padding: 10,
    height: "100%",
    width: "100%",
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
