import Image from "next/image";
import { Row, Col } from 'antd';
import Checkout from "./../../components/checkout";
export default function Home() {
  return (
    <main className="min-h-screen ">
      <Checkout/>
     </main>
  );
}
