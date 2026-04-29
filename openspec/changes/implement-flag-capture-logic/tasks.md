## 1. Setup

- [x] 1.1 Add `esCapturada`, `targetSeguiment`, and `equipPropietari` variables to `Bandera.cs`.

## 2. Capture Logic

- [x] 2.1 Implement `OnTriggerEnter2D` in `Bandera.cs`.
- [x] 2.2 Add team check logic comparing player team to `equipPropietari`.
- [x] 2.3 Set `esCapturada = true` and `targetSeguiment` upon successful capture.

## 3. Visual Following

- [x] 3.1 Implement `Update` logic for flag following using the carrying offset.
- [x] 3.2 Ensure follow logic only runs if `esCapturada` is true and `targetSeguiment` is not null.

## 4. Verification

- [x] 4.1 Verify flag collision with enemy player triggers capture.
- [x] 4.2 Verify flag collision with friendly player does not trigger capture.
- [x] 4.3 Verify flag follows the capturing player with the specified offset.
