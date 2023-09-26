
from ip import IPAddress, assign_ip, netmask_to_wildcard


def route_ospf(routes: list, Zone_Ospf: dict):
    # so co the ngau nhien tu 1 => 65535
    index = 0

    # net_id = /24
    # host_id = 332/ net_id
    # 0: kiem tra
    # 1: khong kiem tra
    # chi kiem tra cac bit cua ohan net_id

    for r in routes:
        index += 1
        print(f"R{index}")
        lst = ["router ospf 1"]
        area = None
        network = None
        wildcard = None
        for k1, v1 in r.items():
            if "dhcp" not in v1:
                for k2, v2 in Zone_Ospf.items():
                    if v1 in v2:
                        area = k2
                        break
                network = IPAddress(v1).network
                wildcard = netmask_to_wildcard(IPAddress(v1).mask)

                if area is None:
                    raise Exception("Area None")

                lst.append(f"network {network} {wildcard} area {area}")
                # 30.0.0.0 0.0.3.255 area 0 co th thay the cho cong lo
            else:
                lst.append("default-information originate")

        lst.append("exit")
        print("\n".join(lst))


def chapter_7():
    R1 = {
        "giga 0/0": "100.0.0.1/24",
        "giga 3/0": "192.1.14.1/30",
        "giga 2/0": "dhcp",
    }

    R2 = {
        "giga 0/0": "100.0.0.2/24",
        "lo 0": "20.0.0.1/24",
        "lo 1": "20.0.1.1/24",
        "lo 2": "20.0.2.1/24",
        "lo 3": "20.0.3.1/24",
    }

    R3 = {
        "giga 0/0": "100.0.0.3/24",
        "lo 0": "30.0.0.1/24",
        "lo 1": "30.0.1.1/24",
        "lo 2": "30.0.2.1/24",
        "lo 3": "30.0.3.1/24",
    }

    R4 = {
        "giga 3/0": "192.1.14.2/30",
        "lo 0": "40.0.0.1/24",
        "lo 1": "40.0.1.1/24",
        "lo 2": "40.0.2.1/24",
        "lo 3": "40.0.3.1/24",
    }

    R = [R1, R2, R3, R4]
    Zone_Ospf = {
        0: [
            "100.0.0.1/24",
            "100.0.0.2/24",
            "100.0.0.3/24",
            "30.0.0.1/24",
            "30.0.1.1/24",
            "30.0.2.1/24",
            "30.0.3.1/24",
            "20.0.0.1/24",
            "20.0.1.1/24",
            "20.0.2.1/24",
            "20.0.3.1/24",
        ],
        1: [
            "192.1.14.1/30",
            "192.1.14.2/30",
            "40.0.0.1/24",
            "40.0.1.1/24",
            "40.0.2.1/24",
            "40.0.3.1/24",
        ],
    }
    assign_ip(R, [])
    route_ospf(R, Zone_Ospf)


def chapter_7_thuchanh_1():
    R1 = {
        "fa 0/0": "192.1.12.1/30",
        "serial 1/0": "192.1.14.1/30",
        "fa 0/1": "192.1.13.1/30",
        "lo 0": "10.1.1.1/24",
        "lo 1": "10.0.1.1/24",
        "lo 2": "10.0.2.1/24",
        "lo 3": "10.0.3.1/24",
        "lo 4": "10.0.4.1/24",
    }

    R2 = {
        "fa 0/0": "192.1.12.2/30",
        "fa 0/1": "192.168.100.254/24",
        "serial 1/0": "192.1.24.2/30",
    }

    R4 = {
        "serial 1/0": "192.1.24.1/30",
        "serial 1/1": "192.1.14.2/30",
        "fa 0/0": "192.1.34.1/30",
        "fa 0/1": "dhcp",
        "lo 0": "40.4.4.4/24",
        "lo 1": "40.0.1.1/24",
        "lo 2": "40.0.2.1/24",
        "lo 3": "40.0.3.1/24",
        "lo 4": "40.0.4.1/24",
    }

    R3 = {
        "fa 0/0": "192.1.13.2/30",
        "fa 0/1": "192.1.34.2/30",
    }

    R = [R1, R2, R3, R4]
    Zone_Ospf = {
        0: [
            "10.0.0.1/24",
            "10.0.0.2/24",
            "10.0.0.3/24",
            "10.0.0.4/24",
            "40.0.0.1/24",
            "40.0.1.1/24",
            "40.0.2.1/24",
            "40.0.3.1/24",
            "40.0.4.1/24",
            "192.1.12.1/30",
            "192.1.12.2/30",
            "192.1.13.1/30",
            "192.1.13.2/30",
            "192.1.14.1/30",
            "192.1.14.2/30",
            "192.1.24.1/30",
            "192.1.24.2/30",
            "192.1.34.1/30",
            "192.1.34.2/30",
        ]
    }
    assign_ip(R, [])
    route_ospf(R, Zone_Ospf)