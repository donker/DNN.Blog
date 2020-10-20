import * as React from "react";
import * as Models from "../../Models/";

interface IFooProps {
  module: Models.IAppModule;
  bar: string;
}

interface IFooState {}

export default class Foo extends React.Component<IFooProps, IFooState> {
  refs: {};

  constructor(props: IFooProps) {
    super(props);
    this.state = {};
  }

  public render(): JSX.Element {
    return <div>{this.props.bar}</div>;
  }
}
