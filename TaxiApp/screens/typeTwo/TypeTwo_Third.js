import React, { Component, useState } from "react";
import {
  Text,
  StyleSheet,
  View,
  Button,
  StatusBar,
  TouchableOpacity,
  FlatList,
} from "react-native";
import DateTimePicker from "@react-native-community/datetimepicker";

export default class TypeTwo_Third extends Component {
  constructor(props) {
    super(props);
    this.state = {
      startDate: new Date("2020-12-01"),
      endDate: new Date("2020-12-01"),
      show: false,
      startEnd: 0,
      data: "",
    };
    this.onChange = this.onChange.bind(this);
  }

  onChange = (event, selectedDate) => {
    const currentDate = selectedDate || new Date("2020-12-01");
    if (this.state.startEnd == 0) {
      this.setState({ startDate: currentDate });
    } else {
      this.setState({ endDate: currentDate });
      
    }
    this.setState({ show: false });
    this.getData();
  };

  showDatepicker = (startEndParam) => {
    this.setState({ startEnd: startEndParam });
    this.setState({ show: true });
  };

  getStartDate = () => {
    return (
      this.state.startDate.getFullYear() +
      "-" +
      "12" +
      "-" +
      this.state.startDate.getDate()
    );
  };

  getEndDate = () => {
    return (
      this.state.endDate.getFullYear() +
      "-" +
      "12" +
      "-" +
      this.state.endDate.getDate()
    );
  };

  getData() {
    var myHeaders = new Headers();
    myHeaders.append("start", this.getStartDate());
    myHeaders.append("end", this.getEndDate());
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({
      start: this.getStartDate(),
      end: this.getEndDate(),
    });

    var requestOptions = {
      method: "POST",
      headers: myHeaders,
      body: raw,
      redirect: "follow",
    };

    fetch(
      "https://taxiappwebapi20210423191539.azurewebsites.net/api/TypeTwo/GetThird",
      requestOptions
    )
      .then((response) => response.json())
      .then((result) => this.setState({ data: result }))
      .catch((error) => console.log("error", error));
  }

  render() {
    return (
      <View style={styles.container}>
        <View style={styles.info}>
          <Text style={styles.text}>
            Başlangıç Tarihi: {this.getStartDate()}
          </Text>
          <Text style={styles.text}>Bitiş Tarihi: {this.getEndDate()}</Text>
        </View>
        <View style={styles.content}>
          <TouchableOpacity onPress={() => this.showDatepicker(0)}>
            <Text style={styles.button}>Başlangıç Tarihi</Text>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => this.showDatepicker(1)}>
            <Text style={styles.button}>Bitiş Tarihi</Text>
          </TouchableOpacity>
        </View>
        {this.state.data != null && (
          <FlatList
            keyExtractor={(item) => Math.random(0, 9999).toString()}
            data={this.state.data}
            renderItem={({ item }) => (
              <View style={styles.item}>
                <Text style={styles.text}>
                  Biniş Tarihi: {item.pickupDatetime}
                </Text>
                <Text style={styles.text}>
                  İniş Tarihi: {item.dropoffDatetime}
                </Text>
                <Text style={styles.text}>Mesafe: {item.tripDistance}mil</Text>
              </View>
            )}
          />
        )}
        {this.state.show && (
          <DateTimePicker
            testID="dateTimePicker"
            value={new Date("2020-12-01")}
            mode={"date"}
            is24Hour={true}
            display="default"
            onChange={this.onChange}
            minimumDate={new Date("2020-12-01")}
            maximumDate={new Date("2020-12-30")}
          />
        )}
        <StatusBar style="dark" />
      </View>
    );
  }
}
const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#121212",
    padding: 15,
  },
  content: {
    paddingTop: 5,
    paddingBottom: 10,
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-around",
    width: "100%",
  },
  text: {
    fontSize: 16,
    color: "#E1E1E1",
  },
  item: {
    marginTop: 5,
    padding: 20,
    backgroundColor: "#1E1E1E",
    borderRadius: 5,
    borderLeftColor: "#bb86fc",
    borderWidth: 2,
    width: "100%",
  },
  info: {
    marginTop: 5,
    padding: 20,
    backgroundColor: "#1E1E1E",
    borderRadius: 5,
    borderColor: "#bb86fc",
    borderWidth: 1,
    width: "100%",
  },
  button: {
    width: "100%",
    fontSize: 16,
    padding: 20,
    fontWeight: "bold",
    color: "#1E1E1E",
    textAlign: "center",
    backgroundColor: "#bb86fc",
    borderRadius: 5,
  },
});
